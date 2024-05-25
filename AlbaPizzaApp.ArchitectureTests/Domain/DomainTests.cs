using AlbaPizzaApp.Domain.Abstractions;
using FluentAssertions;
using NetArchTest.Rules;
using System.Reflection;

namespace AlbaPizzaApp.ArchitectureTests.Domain;
public class DomainTests
{
    /// <summary>
    /// Este test es para asegurarnos que todas las clases que hereden de Entity tengan un constructor privado.
    /// De esta manera nos aseguramos que las instancias de estas entidades solo se pueda crear con metodos de fabrica.
    /// </summary>
    [Fact]
    public void Entities_ShouldHave_PrivateParameterlessConstructor()
    {
        IEnumerable<Type> entityTypes = Types.InAssembly(typeof(Entity).Assembly)
            .That().Inherit(typeof(Entity)).GetTypes();

        var failingTypes = new List<Type>();
        foreach (Type entityType in entityTypes)
        {
            ConstructorInfo[] constructors = entityType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);

            if (!constructors.Any(c => c.IsPrivate))
            {
                failingTypes.Add(entityType);
            }
        }

        failingTypes.Should().BeEmpty();
    }
}
