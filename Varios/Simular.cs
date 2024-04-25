namespace Varios;

public class Simular
{
    public long simularSinHilos(Bolillero bolillero, int Cantidad, List<int> bolillas,long Aciertos)
        => bolillero.JugadaNV(bolillas,Cantidad);
    public long simularConHilos(Bolillero bolillero, int Cantidad,List<int> bolillas,long hilos)
    {
        Task<long>[] tareas = new Task<long>[hilos];
        long result = Cantidad / hilos;
        long res = Cantidad % hilos;
        Bolillero Clon=bolillero.Clon(bolillero);
        
        tareas[0] = Clon.JugadaNV(bolillas,Cantidad);
        
        for (long i = 1; i < hilos; i++)
            tareas[i] = Clon.JugadaNV(bolillas, Cantidad);

        Task.WaitAll(tareas);
        return tareas.Sum(t => t.Result);
    }

}


