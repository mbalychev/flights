/// <summary>
/// класс пагинации для спиской с моделями
/// </summary>
public class Pagination
{
    /// <summary>
    /// без параметров
    /// </summary>
    public Pagination()
    {
    }

    /// <summary>
    /// конструктор с параметрами
    /// </summary>
    /// <param name="page">тек стр</param>
    /// <param name="onPage">на стрнице</param>
    /// <param name="total">всего позиций</param>
    public Pagination(short page, short onPage, int total)
    {
        Page = page;
        OnPage = onPage;
        Total = total;
    }

    /// <summary>
    ///тек страница
    /// </summary>
    /// <value></value>
    public short Page { get; set; } = 1;
    /// <summary>
    /// кол-во позиций на странице
    /// </summary>
    /// <value></value>
    public short OnPage { get; set; } = 20;
    /// <summary>
    ///общее кол-во позиций
    /// </summary>
    /// <value></value>
    public int Total { get; set; } = 0;

}