namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;

public class RepositorioVehiculoTXT : IRepositorioVehiculo
{
    readonly string path = "./vehiculos.txt";
    readonly string _nombreArch = "vehiculos.txt";

    int id = 1;

    public void AgregarVehiculo(Vehiculo vehiculo)        
    {   
        if ((vehiculo.Dominio != null) && !existeVehiculo(vehiculo.Dominio))
        {
            if (File.Exists(path)){   
                using var sw = new StreamWriter(_nombreArch, true);
                {
                    vehiculo.Id = proximaId();
                    sw.WriteLine($"{vehiculo.Id}*{vehiculo.Dominio}*{vehiculo.Marca}*{vehiculo.Anio}*{vehiculo.TitularId}");
                }            
            }else 
                using (StreamWriter sw = File.AppendText(path))
                {
                    vehiculo.Id = id++;         
                    sw.WriteLine($"{vehiculo.Id}*{vehiculo.Dominio}*{vehiculo.Marca}*{vehiculo.Anio}*{vehiculo.TitularId}");                               
                }
        }else
        {
            throw new Exception($"Ya se encuentra registrado un vehiculo con el Dominio: {vehiculo.Dominio}");
        }
    }   

    //Se queda con la ultima id ya registrada en el text y retorno el siguiente numero
    private int proximaId()
    {        
        int id = int.Parse(File.ReadLines(path).Last().Split("*")[0]); 
        return id +1 ;
    }
    private Boolean existeVehiculo(string dominio)
    {
        if (File.Exists(path)){
            using var sr = new StreamReader(_nombreArch);
            while(!sr.EndOfStream)
            {
                string str = sr.ReadLine() ?? "";
                string d = (str.Split("*")[1]); 
                if(d.Equals(dominio))
                {
                    return true;
                }
            }  
        }                  
        return false;        
    }  

    public void ModificarVehiculo(Vehiculo vehiculo)
    {
        if ((vehiculo.Dominio != null) && existeVehiculo(vehiculo.Dominio))
        { 
            using var sr = new StreamReader(_nombreArch);          
            string str = sr.ReadLine() ?? "";                    
            int idN = int.Parse(str.Split("*")[0]);
            string dominio = (str.Split("*")[1]);    
            while(!sr.EndOfStream && (dominio != vehiculo.Dominio))
            {
                str = sr.ReadLine() ?? "";           
                idN = int.Parse(str.Split("*")[0]); 
                dominio = (str.Split("*")[1]);           
            }
            //transforma todo el texto en un array donde cada linea es un inidice, luego me paro en el inidice = id-1 y lo sobreescribo
            if(idN == vehiculo.Id)
            {
                string[] lines = File.ReadAllLines(path);
                vehiculo.Id = idN;
                lines[idN-1] = ($"{vehiculo.Id}*{vehiculo.Dominio}*{vehiculo.Marca}*{vehiculo.Anio}*{vehiculo.TitularId}");
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
            throw new Exception($"No se encuentra registrado un vehiculo con Dominio: {vehiculo.Dominio}");
        }   
    }
    public void EliminarVehiculo(int id)
    {
        using var sr = new StreamReader(_nombreArch);
        var v = new Vehiculo();
        string str = sr.ReadLine() ?? "";
        v.Id = int.Parse(str.Split("*")[0]);
        v.Dominio = (str.Split("*")[1]);
        v.Marca = (str.Split("*")[2]);
        v.Anio = int.Parse(str.Split("*")[3]);  
        v.TitularId = int.Parse(str.Split("*")[4]);   
        while(!sr.EndOfStream && (v.Id != id))
        {
            str = sr.ReadLine() ?? "";
            v.Id = int.Parse(str.Split("*")[0]);
            v.Dominio = (str.Split("*")[1]);
            v.Marca = (str.Split("*")[2]);
            v.Anio = int.Parse(str.Split("*")[3]);    
            v.TitularId = int.Parse(str.Split("*")[4]);      
        }
        if(v.Id == id)
        {
            v.Marca = "ELIMINAD@";
            ModificarVehiculo(v);
        }
        else
        {
            throw new Exception($"No se encuentra registrado un vehiculo con esa id");
        }
    }
    public List<Vehiculo> ListarVehiculos()
    {
        var lista = new List<Vehiculo>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var vehiculo = new Vehiculo();
            string str = sr.ReadLine() ?? "";
            vehiculo.Id = int.Parse(str.Split("*")[0]);
            vehiculo.Dominio = (str.Split("*")[1]);
            vehiculo.Marca = (str.Split("*")[2]);
            vehiculo.Anio = int.Parse(str.Split("*")[3]);
            vehiculo.TitularId = int.Parse(str.Split("*")[4]);
            if (vehiculo.Marca != "ELIMINAD@")
            {
                lista.Add(vehiculo);
            }
        }
        return lista;
    }

    public List<Vehiculo> ListarVehiculosDelTitular (int id)
    {
        var lista = new List<Vehiculo>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var vehiculo = new Vehiculo();
            string str = sr.ReadLine() ?? "";
            vehiculo.Id = int.Parse(str.Split("*")[0]);
            vehiculo.Dominio = (str.Split("*")[1]);
            vehiculo.Marca = (str.Split("*")[2]);
            vehiculo.Anio = int.Parse(str.Split("*")[3]);
            vehiculo.TitularId = int.Parse(str.Split("*")[4]);
            if (vehiculo.TitularId == id && vehiculo.Marca != "ELIMINAD@")
            {
                lista.Add(vehiculo);
            }
        }
        return lista;

    }
}
