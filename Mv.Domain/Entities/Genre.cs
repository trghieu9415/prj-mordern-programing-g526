using Domain.Base;

namespace Domain.Entities;

public class Genre : BaseEntity {
  private Genre() {}

  public string Name { get; private set; } = null!;

  public string? Description { get; private set; }

  public static Genre Create(string name, string? description = null) {
    var genre = new Genre {
      Name = name,
      Description = description
    };

    return genre;
  }

  public Genre Update(string name, string? description) {
    Name = name;
    Description = description;
    return this;
  }
}
