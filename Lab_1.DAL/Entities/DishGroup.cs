namespace Lab_1.DAL.Entities;

/// <summary>
/// 
/// </summary>
public class DishGroup
{
    /// <summary>
    /// 
    /// </summary>
    public int DishGroupId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string GroupName { get; set; }

    /// <summary>
    /// Навигационное свойство 1-ко-многим
    /// </summary>
    public List<Dish> Dishes { get; set; }
}