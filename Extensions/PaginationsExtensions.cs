using flights.models;

namespace flights.Extensions
{

    /// <summary>
    /// расширение для проверки валидности пагинации
    /// </summary>
    public static class PaginationsExtensions
    {
        /// <summary>
        /// стандартная ошибка при проверке
        /// </summary>
        /// <returns></returns>
        public static ErrorView BadPaginationMessage()
        {
            return new ErrorView("ошибка", "не верная модель пагинации");
        }

        /// <summary>
        /// проверка модели пагинации на корректность
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public static bool CheckPagination(this Pagination? pagination)
        {

            if (pagination is null) return true;

            if (pagination.OnPage <= 0 || pagination.Page <= 0) return false;

            return true;
        }
    }
}