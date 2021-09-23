using AppDependencyInject_Lab.Models;

namespace AppDependencyInject_Lab.Service
{
    public interface IZombieForecaster
    {
        NbrZombiesResult GetVillagePrediction();
    }
}