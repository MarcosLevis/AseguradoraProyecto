namespace Aseguradora.Repositorios;
public class RepositorioPolizaTXT : IRepositorioPoliza
{
    readonly string path = "./polizas.txt";
    readonly string _nombreArch = "polizas.txt";
    int id = 1;

    ///El siguiente metodo agregar poliza comprueba que no exista una poliza ya registrada para ese vehiculo enviado como parametro.
    //Luego verifica si existe un archivo de persistencia de polizas.
    //En caso de que no exisa  un txt, lo crea y escribe la poliza asignandole una id unica.
    //En caso de que exista un txt, le escribe la poliza alfinal del archivo asignandole una id unica.
    public void AgregarPoliza(Poliza poliza)        
    {   
        if ((poliza.VehiculoId != null ) && !existePoliza(poliza.VehiculoId))
        {       
            if (File.Exists(path))
            {   
                using var sw = new StreamWriter(_nombreArch, true);
                {
                    poliza.Id = proximaId();
                    sw.WriteLine($"{poliza.Id}*{poliza.ValorAsegurado}*{poliza.Cobertura}*{poliza.Franquicia}*{poliza.FechaInicio}*{poliza.FechaFin}*{poliza.VehiculoId}");
                }            
            }else 
                using (StreamWriter sw = File.AppendText(path))
                {
                    poliza.Id = id++;         
                    sw.WriteLine($"{poliza.Id}*{poliza.ValorAsegurado}*{poliza.Cobertura}*{poliza.Franquicia}*{poliza.FechaInicio}*{poliza.FechaFin}*{poliza.VehiculoId}");                              
                }
        }else
            {
                throw new Exception("El vehiculo ya posee una poliza");
            }
   
    }   

    //El siguiente metodo se queda con la id de la ultima poliza ya persistida en el text y retorna el siguiente numero
    private int proximaId()
    {        
        int id = int.Parse(File.ReadLines(path).Last().Split("*")[0]); 
        return id +1 ;
    }
    //El siguiente metodo verifica que exista una poliza asignada a un vehiculo pasado por parametro
    private Boolean existePoliza(int? idVehiculo)
    {
        if (File.Exists(path)){
            using var sr = new StreamReader(_nombreArch);
            while(!sr.EndOfStream)
            {
                string str = sr.ReadLine() ?? "";
                int d = int.Parse(str.Split("*")[6]); 
                if(d == idVehiculo)
                {
                    return true;
                }
            }  
        }                  
        return false;        
    } 
    // El siguiente metodo recibe una poliza por parametro.
    // Luego busca su posicion en el archivo y reescribe todo el texto modificando la linea correspondiente a donde esta ubicada la poliza a modificar
    public void ModificarPoliza(Poliza poliza)
    {
        if (existePoliza(poliza.VehiculoId))
        {
            using var sr = new StreamReader(_nombreArch);            
            string str = sr.ReadLine() ?? "";
            int id = int.Parse(str.Split("*")[0]);
            int vId = int.Parse(str.Split("*")[6]); 
            while(!sr.EndOfStream && (vId != poliza.VehiculoId))
            {
                str = sr.ReadLine() ?? "";           
                id = int.Parse(str.Split("*")[0]);    
                vId = int.Parse(str.Split("*")[6]);          
            }
            //transforma todo el texto en un array donde cada linea es un inidice, luego me paro en el inidice = id-1 y lo sobreescribo

            if(vId == poliza.VehiculoId)
            {
                string[] lines = File.ReadAllLines(path);
                poliza.Id = id;
                lines[id-1] = ($"{poliza.Id}*{poliza.ValorAsegurado}*{poliza.Cobertura}*{poliza.Franquicia}*{poliza.FechaInicio}*{poliza.FechaFin}*{poliza.VehiculoId}");
                using (StreamWriter sw = new StreamWriter(path)) 
                {
                    foreach (string line in lines) 
                    {
                        sw.WriteLine(line);
                    }
                }
            }
        }
        else
        {
            throw new Exception("La poliza no ha sido registrada");
        }
           
    }
    // El siguiente metodo recide la id de una poliza a ser eliminada.
    //En caso de que esa poliza existe la elimina de manera LOGICA modificando su "Franquicia"
    public void EliminarPoliza(int id)
    {
        using var sr = new StreamReader(_nombreArch);
        var p = new Poliza();
        string str = sr.ReadLine() ?? "";
        p.Id = int.Parse(str.Split("*")[0]);
        p.ValorAsegurado = double.Parse(str.Split("*")[1]);
        p.Cobertura = str.Split("*")[2];
        p.Franquicia = str.Split("*")[3];  
        p.FechaInicio = DateTime.Parse(str.Split("*")[4]);   
        p.FechaFin = DateTime.Parse(str.Split("*")[5]);  
        p.VehiculoId = int.Parse(str.Split("*")[6]); 
        while(!sr.EndOfStream && (p.Id != id))
        {
            str = sr.ReadLine() ?? "";
            p.Id = int.Parse(str.Split("*")[0]);
            p.ValorAsegurado = double.Parse(str.Split("*")[1]);
            p.Cobertura = (str.Split("*")[2]);
            p.Franquicia = str.Split("*")[3];  
            p.FechaInicio = DateTime.Parse(str.Split("*")[4]);   
            p.FechaFin = DateTime.Parse(str.Split("*")[5]);  
            p.VehiculoId = int.Parse(str.Split("*")[6]);     
        }
        if(p.Id == id)
        {
            p.Franquicia = "ELIMINAD@";
            ModificarPoliza(p);
        }
        else
        {
            throw new Exception("No existe una poliza registrada con esa Id");
        }
    }
    //El siguiente metodo retorna una lista con las polizas persistidas en el txt que no fueron eliminadas de forma logica
    public List<Poliza> ListarPolizas()
    {
        var lista = new List<Poliza>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var p = new Poliza();
            string str = sr.ReadLine() ?? "";
            p.Id = int.Parse(str.Split("*")[0]);
            p.ValorAsegurado = double.Parse(str.Split("*")[1]);
            p.Cobertura = str.Split("*")[2];
            p.Franquicia = str.Split("*")[3];  
            p.FechaInicio = DateTime.Parse(str.Split("*")[4]);
            p.FechaFin = DateTime.Parse(str.Split("*")[5]);
            p.VehiculoId = int.Parse(str.Split("*")[6]);   
            if (p.Franquicia != "ELIMINAD@")
            {
                lista.Add(p);
            }
        }
        return lista;
    }
}
