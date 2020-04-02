using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    /// <summary>
    /// Базовый класс для мапинга models в DTO
    /// </summary>
    /// <typeparam name="T1">model</typeparam>
    /// <typeparam name="T2">DTO</typeparam>
    public interface IMapper<T1, T2>
    {
        T2 GetDTO(T1 model);
        T1 GetModel(T2 model);
        IEnumerable<T2> GetDTOs(IEnumerable<T1> models);
        IEnumerable<T1> GetModels(IEnumerable<T2> models);
    }
}
