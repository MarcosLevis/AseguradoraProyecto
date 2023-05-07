using System.Globalization;

namespace Aseguradora.Repositorios;
public class RepositorioPolizaTXT : IRepositorioPoliza
{
    readonly string path = "./polizas.txt";
    readonly string _nombreArch = "polizas.txt";
    int id = 1;
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

    //Se queda con la ultima id ya registrada en el text y retorno el siguiente numero
    private int proximaId()
    {        
        int id = int.Parse(File.ReadLines(path).Last().Split("*")[0]); 
        return id +1 ;
    }

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
