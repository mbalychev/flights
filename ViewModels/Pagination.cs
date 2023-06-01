/// <summary>
/// класс пагинации для спиской с моделями
/// </summary>
public class Pagination
{
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
    public int total { get; set; } = 0;

}