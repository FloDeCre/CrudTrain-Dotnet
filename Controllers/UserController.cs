using UserModelName;
using UserDtoName;
using UserDatabase;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace UserControllerName;

public class UserController
{

    public static async Task<IResult> GetAllTodos(UserDb db)
    {
        return TypedResults.Ok(await db.Users.Select(x => new UserDTO(x)).ToArrayAsync());
    }

    public static async Task<IResult> GetTodo(int id, UserDb db)
    {
        return await db.Users.FindAsync(id)
            is UserModel todo
                ? TypedResults.Ok(new UserDTO(todo))
                : TypedResults.NotFound();
    }

    public static async Task<IResult> CreateTodo(UserDTO UserDTO, UserDb db)
    {
        var userItem = new UserModel
        {
            Name = UserDTO.Name
        };

        db.Users.Add(userItem);
        await db.SaveChangesAsync();

        UserDTO = new UserDTO(userItem);

        return TypedResults.Created($"/update/{userItem.Id}", UserDTO);
    }

    public static async Task<IResult> UpdateTodo(int id, UserDTO UserDTO, UserDb db)
    {
        var todo = await db.Users.FindAsync(id);

        if (todo is null) return TypedResults.NotFound();
        Console.WriteLine(UserDTO);
        todo.Name = UserDTO.Name;

        await db.SaveChangesAsync();

        return TypedResults.NoContent();
    }

    public static async Task<IResult> DeleteTodo(int id, UserDb db)
    {
        if (await db.Users.FindAsync(id) is UserModel todo)
        {
            db.Users.Remove(todo);
            await db.SaveChangesAsync();
            return TypedResults.NoContent();
        }

        return TypedResults.NotFound();
    }
}