namespace EcoSimGame.Models.Materials;

public static class RecipeList
{
    public static Dictionary<string, Dictionary<string, int>> Recipes { get; } = new()
    {
        // Materiały przetworzone
        { "Ferron", new() { { "Ferronit", 2 } } },
        { "Plastium", new() { { "Plastotyt", 2 } } },
        { "Quarzite", new() { { "Kwarcyn", 2 } } },
        { "Voltite", new() { { "Voltanium", 2 } } },

        // Półprodukty
        { "Ferron Frame", new() { { "Ferron", 5 } } },
        { "Plastoid Sheet", new() { { "Plastium", 5 } } },
        { "Quarz Chip", new() { { "Quarzite", 5 } } },
        { "Volt Core", new() { { "Voltite", 5 } } },

        // Komponenty zaawansowane
        { "NanoStructure", new() { { "Ferron Frame", 2 }, { "Plastoid Sheet", 2 } } },
        { "Quantum CPU", new() { { "Quarz Chip", 2 }, { "Volt Core", 2 } } },

        // Produkt końcowy
        { "Stacja Kolonizacyjna", new()
            {
                { "NanoStructure", 20 },
                { "Quantum CPU", 10 }
            }
        }
    };

    public static Dictionary<string, int>? GetRecipe(string materialName) =>
        Recipes.TryGetValue(materialName, out var recipe) ? recipe : null;
}