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
        /// <summary> Создание на основе модели => DTO </summary>
        /// <param name="model">исходная модель</param>
        T2 GetDTO(T1 model);
        /// <summary> Создание на основе DTO => НОВОЙ модели </summary>
        /// <param name="dto">исходная DTO</param>
        T1 GetNewModel(T2 dto);
        /// <summary> Создание на основе моделей => DTOs </summary>
        /// <param name="models">исходные модели</param>
        IEnumerable<T2> GetDTOs(IEnumerable<T1> models);
        /// <summary> Создание на основе DTOs => НОВЫХ моделей </summary>
        /// <param name="dtos">исходные DTOs</param>
        IEnumerable<T1> GetNewModels(IEnumerable<T2> dtos);
    }
}
