using System;

namespace App.Service.Web
{
    public interface ICasheService
    {
        T Get<T>(string itemName, Func<T> getDataFunc, int durationInSeconds);

        void Remove(string itemName);
    }
}
