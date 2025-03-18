using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.ValueObjects;

public class ProductResponse
{
    public List<Product> Data { get; set; }
    public int TotalItems { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }

    public ProductResponse(List<Product> data, int totalItems, int currentPage, int totalPages)
    {
        Data = data;
        TotalItems = totalItems;
        CurrentPage = currentPage;
        TotalPages = totalPages;
    }
}

public class CartResponse
{
    public List<Cart> Data { get; set; }
    public int TotalItems { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }

    public CartResponse(List<Cart> data, int totalItems, int currentPage, int totalPages)
    {
        Data = data;
        TotalItems = totalItems;
        CurrentPage = currentPage;
        TotalPages = totalPages;
    }
}

public class UserResponse
{
    public List<User> Data { get; set; }
    public int TotalItems { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }

    public UserResponse(List<User> data, int totalItems, int currentPage, int totalPages)
    {
        Data = data;
        TotalItems = totalItems;
        CurrentPage = currentPage;
        TotalPages = totalPages;
    }
}