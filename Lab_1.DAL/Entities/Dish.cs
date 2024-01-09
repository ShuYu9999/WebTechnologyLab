namespace Lab_1.DAL.Entities;

/// <summary>
/// 
/// </summary>
public class Dish
{
    /// <summary>
    /// id блюда
    /// </summary>
    public int DishId { get; set; }

    /// <summary>
    /// название блюда
    /// </summary>
    public string? DishName { get; set; }

    /// <summary>
    /// описание блюда
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// кол. калорий на порцию
    /// </summary>
    public int Calories { get; set; }

    /// <summary>
    /// имя файла изображения 
    /// </summary>
    public string? Image { get; set; }

    // Навигационные свойства
    /// <summary>
    /// группа блюд (например, супы, напитки и т.д.)
    /// </summary>
    public int DishGroupId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DishGroup? Group { get; set; }

}
