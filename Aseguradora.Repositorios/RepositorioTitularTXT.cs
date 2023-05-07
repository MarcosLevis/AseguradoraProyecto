﻿namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;

public class RepositorioTitularTXT : IRepositorioTitular 
{
    readonly string path = "./titulares.txt";
    readonly string _nombreArch = "titulares.txt";   
    private int id = 1;
    
    ///Si no existe el txt, lo crea y le escribe los nuevos titulares, en caso contrario escribe alfinal del txt los nuevos titulares
    public void AgregarTitular(Titular titular) 
    {        
        if (existeTitular(titular.Dni) == -1)
        {                                
            if (File.Exists(path)){   
                using var sw = new StreamWriter(_nombreArch, true);
                {
                    titular.Id = proximaId();
                    sw.WriteLine($"{titular.Id}*{titular.Apellido}*{titular.Nombre}*{titular.Dni}*{titular.Telefono}*{titular.Direccion}*{titular.Correo}");
                }            
            }else 
                using (StreamWriter sw = File.AppendText(path))
                {
                    titular.Id = id++;         
                    sw.WriteLine($"{titular.Id}*{titular.Apellido}*{titular.Nombre}*{titular.Dni}*{titular.Telefono}*{titular.Direccion}*{titular.Correo}");                               
                }
        }else 
            {
            throw new Exception($"Ya se encuentra registrado un titular con el Dni {titular.Dni}");
            }
    }

    //Se queda con la ultima id ya registrada en el text y retorno el siguiente numero
    private int proximaId()
    {        
        int id = int.Parse(File.ReadLines(path).Last().Split("*")[0]); 
        return id +1 ;
    }

    // Pregunta si existe un titular con el dni ingresado, en vez de un boolean retorna la id por si la necesitamos. 
    private int existeTitular(int dni)
    {
        if (File.Exists(path)){
            using var sr = new StreamReader(_nombreArch);
            while(!sr.EndOfStream)
            {
                string str = sr.ReadLine() ?? "";
                int d = int.Parse(str.Split("*")[3]); 
                int id = int.Parse(str.Split("*")[0]);
                if(d == dni)
                {
                    return id;
                }
            }  
        }                  
        return -1;        
    }  

    //Este metodo sobreescribe todo el txt para modificar un registro del titular, es ineficiente pero cumple con la consigna a modo de ejemplo.
    public void ModificarTitular(Titular titular)
    {
        if (existeTitular(titular.Dni) != -1)
        {
            using var sr = new StreamReader(_nombreArch);            
            string str = sr.ReadLine() ?? "";
            int dni = int.Parse(str.Split("*")[3]);
            int idN = int.Parse(str.Split("*")[0]);
            while(!sr.EndOfStream && (dni != titular.Dni))
            {
                str = sr.ReadLine() ?? "";
                dni = int.Parse(str.Split("*")[3]);  
                idN = int.Parse(str.Split("*")[0]);          
            }
            //transforma todo el texto en un array donde cada linea es un inidice, luego me paro en el inidice = id-1 y lo sobreescribo
            if(dni == titular.Dni)
            {
                string[] lines = File.ReadAllLines(path);
                titular.Id = idN;
                lines[idN-1] = ($"{titular.Id}*{titular.Apellido}*{titular.Nombre}*{titular.Dni}*{titular.Telefono}*{titular.Direccion}*{titular.Correo}");
                using (StreamWriter sw = new StreamWriter(path)) 
                {
                    foreach (string line in lines) 
                    {
                        sw.WriteLine(line);
                    }
                }   
            }
        }else
        {
            throw new Exception($"No existe un titular registrado con el dni {titular.Dni}");
        }
      
    }

    //El eliminar titular va a hacer una baja logica, modificando solo el nombre, y el listar solo retornara aquellos que no tengan esa modificacion
    //Para este metodo tambien sobreescribe todo el txt.
    public void EliminarTitular(int id) 
    {            
        using var sr = new StreamReader(_nombreArch);
        var t = new Titular();
        string str = sr.ReadLine() ?? "";
        t.Id = int.Parse(str.Split("*")[0]);
        t.Apellido = (str.Split("*")[1]);
        t.Nombre = (str.Split("*")[2]);       
        t.Dni = int.Parse(str.Split("*")[3]);
        t.Telefono = int.Parse(str.Split("*")[4]);
        t.Direccion = (str.Split("*")[5]);
        t.Correo = (str.Split("*")[6]);
        while(!sr.EndOfStream && (t.Id != id))
        {
            str = sr.ReadLine() ?? "";
            t.Id = int.Parse(str.Split("*")[0]);
            t.Apellido = (str.Split("*")[1]);
            t.Nombre = (str.Split("*")[2]);            
            t.Dni = int.Parse(str.Split("*")[3]);
            t.Telefono = int.Parse(str.Split("*")[4]);
            t.Direccion = (str.Split("*")[5]);
            t.Correo = (str.Split("*")[6]);         
        }
        if (existeTitular(t.Dni) != -1)
        {
            if(t.Id == id)
            {
                t.Nombre = "ELIMINAD@";
                ModificarTitular(t);
            }
        }
        else 
        {
            throw new Exception($"No existe un Titular registrado que posea esa id");
        }
     

    }
    ///retorna una lista con todos los titulares.
    public List<Titular> ListarTitulares()
    {
        var lista = new List<Titular>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream)
        {
            var titular = new Titular();
            string str = sr.ReadLine() ?? "";
            titular.Id = int.Parse(str.Split("*")[0]);
            titular.Apellido = (str.Split("*")[1]);
            titular.Nombre = (str.Split("*")[2]);            
            titular.Dni = int.Parse(str.Split("*")[3]);
            titular.Telefono = int.Parse(str.Split("*")[4]);
            titular.Direccion = (str.Split("*")[5]);
            titular.Correo = (str.Split("*")[6]);
            if (titular.Nombre != "ELIMINAD@")
            {
                lista.Add(titular);
            }
        }
        return lista;
    }



}