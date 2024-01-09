using Lab_1.DAL.Entities;
using Lab_1.Models;

namespace Lab_1.Tests;

/// <summary>
/// 
/// </summary>
public class ListViewModelTests
{
    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void ListViewModelCountsPages()
    {
        // Act
        var model = ListViewModel<Dish>
       .GetModel(TestData.GetDishesList(), 1, 3);
        // Assert
        Assert.Equal(2, model.TotalPages);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="page"></param>
    /// <param name="qty"></param>
    /// <param name="id"></param>
    [Theory]
    [MemberData(memberName: nameof(TestData.Params), MemberType = typeof(TestData))]
    public void ListViewModelSelectsCorrectQty(int page, int qty, int id)
    {
        // Act
        var model = ListViewModel<Dish>
       .GetModel(TestData.GetDishesList(), page, 3);
        // Assert
        Assert.Equal(qty, model.Count);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="page"></param>
    /// <param name="qty"></param>
    /// <param name="id"></param>
    [Theory]
    [MemberData(memberName: nameof(TestData.Params), MemberType = typeof(TestData))]
    public void ListViewModelHasCorrectData(int page, int qty, int id)
    {
        // Act
        var model = ListViewModel<Dish>
       .GetModel(TestData.GetDishesList(), page, 3);
        // Assert
        Assert.Equal(id, model[0].DishId);
    }
}