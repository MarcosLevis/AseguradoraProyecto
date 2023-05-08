﻿namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;

public class RepositorioTitularTXT : IRepositorioTitular 
{
    readonly string path = "./titulares.txt";
    readonly string _nombreArch = "titulares.txt";   
    private int id = 1;
    
    //El siguiente metodo agrega un Titular recibido por parametro, comprueba que no exista un Titular ya registrado con ese Dni.
    //Luego verifica si existe un archivo de persistencia de Titulares.
    //En caso de que no exista  un txt, lo crea y escribe el Titular asignandole una id unica.
    //En caso de que exista un txt, le escribe un el Titular al final del archivo asignandole una id unica.
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

    //El siguiente metodo retorna la siguiente id del ultimo Titular ya persistido en el text.
    private int proximaId()
    {        
        int id = int.Parse(File.ReadLines(path).Last().Split("*")[0]); 
        return id +1 ;
    }

    // El siguiente metodo pregunta si existe un titular persistido con el dni ingresado por parametro.
    // (en vez de un boolean retorna la id por si la necesitamos) 
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

    //El siguiente metodo modifica un titular ingresado por parametro.
    //Recorre todo el txt hasta encontrar la posicion del titular a modificar. 
    //En caso de encontrarlo reescribe todo el txt modificando solo la linea que corresponde al titular a modificar.
    // (Es ineficiente pero cumple con la consigna a modo de ejemplo, en la proxima entrega se usaran BD).
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

    // El siguiente metodo recide la id de un Titular a ser eliminado.
    //En caso de que este Titular existe persistido en el txt, lo elimina de manera LOGICA modificando su "Nombre".
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
        if(t.Id == id)
        {               
            
            t.Nombre = "ELIMINAD@";
            ModificarTitular(t);            
        }else 
            {
                throw new Exception($"No existe un Titular registrado que posea esa id");
            } 
    }
    //El siguiente metodo retorna una lista con los Titulares persistidas en el txt que no fueron eliminados de forma logica
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