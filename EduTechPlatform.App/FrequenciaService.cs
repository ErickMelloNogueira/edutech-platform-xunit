namespace EduTechPlatform.App;

public class FrequenciaService
{
    public double CalcularPorcentagemPresenca(int aulasTotais, int faltas)
    {
        if (aulasTotais <= 0)
        {
            return 0.0;
        }

        int presencas = aulasTotais - faltas;
        return ((double)presencas / aulasTotais) * 100.0;
    }

    public bool AprovadoPorFrequencia(int aulasTotais, int faltas)
    {
        double percentual = CalcularPorcentagemPresenca(aulasTotais, faltas);
        return percentual >= 75.0;
    }
}