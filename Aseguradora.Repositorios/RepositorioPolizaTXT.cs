namespace Aseguradora.Repositorios;


public class RepositorioPolizaTXT : IRepositorioPoliza
{
    readonly string path = "./polizas.txt";
    readonly string _nombreArch = "polizas.txt";

    readonly string pathVehiculos = "./vehiculos.txt";
    readonly string _nombreVehiculos = "vehiculos.txt";

    int id = 1;

    public void AgregarPoliza(Poliza poliza)        
    {   
        if (!existePoliza(poliza.VehiculoId))
        {
            if (poliza.Vehiculo != null)
            {
                poliza.VehiculoId = idTitular(poliza.Vehiculo.Dominio);
            }
            if (File.Exists(path)){   
                using var sw = new StreamWriter(_nombreArch, true);
                {
                    poliza.Id = proximaId();
                    sw.WriteLine($"{poliza.Id},{poliza.VehiculoId},{poliza.Valor_asegurado},{poliza.Cobertura},{poliza.Franquicia},{poliza.Fecha_inicio},{poliza.Fecha_fin}");
                }            
            }else 
                using (StreamWriter sw = File.AppendText(path))
                {
                    poliza.Id = id++;         
                    sw.WriteLine($"{poliza.Id},{poliza.VehiculoId},{poliza.Valor_asegurado},{poliza.Cobertura},{poliza.Franquicia},{poliza.Fecha_inicio},{poliza.Fecha_fin}");                              
                }
        }else
        {
            Console.WriteLine("Ya esta registrada esta poliza");
        }
    }   

    //Se queda con la ultima id ya registrada en el text y retorno el siguiente numero
    private int proximaId()
    {        
        int id = int.Parse(File.ReadLines(path).Last().Split(",")[0]); 
        return id +1 ;
    }

    private int idTitular(string dominio){
        if (File.Exists(pathVehiculos)){
            using var sr = new StreamReader(_nombreVehiculos);
            string str = sr.ReadLine() ?? "";
            string d = (str.Split(",")[1]); //dominio esta en 1
            int id = int.Parse(str.Split(",")[0]);
            
            while((!sr.EndOfStream) && (d != dominio))
            {
                str = sr.ReadLine() ?? "";
                d = (str.Split(",")[1]); 
                id = int.Parse(str.Split(",")[0]);
            }
            if (d == dominio){
                return id;
            }
        } 
        return -1;         
    }

//listo
    private Boolean existePoliza(int? idTitular)
    {
        if (File.Exists(path)){
            using var sr = new StreamReader(_nombreArch);
            while(!sr.EndOfStream)
            {
                string str = sr.ReadLine() ?? "";
                int d = int.Parse(str.Split(",")[1]); 
                if(d == idTitular)
                {
                    return true;
                }
            }  
        }                  
        return false;        
    }  

    public void ModificarVehiculo(Vehiculo vehiculo)
    {
        using var sr = new StreamReader(_nombreArch);
        var t = new Vehiculo();
        string str = sr.ReadLine() ?? "";
        int idN = int.Parse(str.Split(",")[0]);
        while(!sr.EndOfStream && (idN!= vehiculo.Id))
        {
             str = sr.ReadLine() ?? "";           
             idN = int.Parse(str.Split(",")[0]);          
        }
        //transforma todo el texto en un array donde cada linea es un inidice, luego me paro en el inidice = id-1 y lo sobreescribo
        if(idN == vehiculo.Id)
        {
            string[] lines = File.ReadAllLines(path);
            vehiculo.Id = idN;
            lines[idN-1] = ($"{vehiculo.Id},{vehiculo.Dominio},{vehiculo.Marca},{vehiculo.Anio},{vehiculo.TitularId}");
            using (StreamWriter sw = new StreamWriter(path)) 
            {
                foreach (string line in lines) 
                {
                    sw.WriteLine(line);
                }
            }
        }   
    }


    public void EliminarVehiculo(int id)
    {
        using var sr = new StreamReader(_nombreArch);
        var t = new Vehiculo();
        string str = sr.ReadLine() ?? "";
        t.Id = int.Parse(str.Split(",")[0]);
        t.Dominio = (str.Split(",")[1]);
        t.Marca = (str.Split(",")[2]);
        t.Anio = int.Parse(str.Split(",")[3]);  
        t.TitularId = int.Parse(str.Split(",")[4]);   
        while(!sr.EndOfStream && (t.Id != id))
        {
            str = sr.ReadLine() ?? "";
            t.Id = int.Parse(str.Split(",")[0]);
            t.Dominio = (str.Split(",")[1]);
            t.Marca = (str.Split(",")[2]);
            t.Anio = int.Parse(str.Split(",")[3]);    
            t.TitularId = int.Parse(str.Split(",")[4]);      
        }
        if(t.Id == id)
        {
            t.Dominio = "ELIMINAD@";
            ModificarVehiculo(t);
        }
    }
}
