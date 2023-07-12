/// <summary>
/// класс стандартного вывода ошибок
/// </summary>
public class ErrorView
{
    /// <summary>
    /// конструктор
    /// </summary>
    /// <param name="error">кр описание ошибки</param>
    /// <param name="descriptions">полное описание ошибки</param>
    public ErrorView(string error, string descriptions)
    {
        this.Error = error;
        this.Error_description = descriptions;
    }

    /// <summary>
    /// Код ошибки (тектовый)
    /// </summary>
    /// <value></value>
    public string Error { get; set; } = string.Empty;
    /// <summary>
    /// Человекочитаемое описание ошибки
    /// </summary>
    /// <value></value>
    public string Error_description { get; set; } = string.Empty;
    /// <summary>
    /// [опционально]: ссылка на подробное описание / поддержку
    /// </summary>
    /// <value></value>
    public string? Error_uri { get; set; } = null;
    /// <summary>
    /// [опционально]: результаты валидации входящих данных
    /// </summary>
    /// <value></value>
    public ICollection<string>? Errors { get; set; } = null;
}