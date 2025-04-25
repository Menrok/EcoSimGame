namespace EcoSimGame.Models.List;

public static class RecipeList
{
    public static Dictionary<string, Dictionary<string, int>> Recipes { get; } = new()
    {
        // Materiały przetworzone
        { "Sztabka żelaza", new() { { "Ruda żelaza", 2 } } },
        { "Sztabka miedzi", new() { { "Ruda miedzi", 2 } } },
        { "Sztabka krzemu", new() { { "Ruda krzemu", 2 } } },
        { "Sztabka litu", new() { { "Ruda litu", 2 } } },
        { "Plastik", new() { { "Ropa naftowa", 1 } } },
        { "Kompozyt węglowy", new() { { "Włókno węglowe", 2 } } },

        // Produkty – napęd rakietowy
        { "Silnik główny", new() { { "Sztabka żelaza", 2 }, { "Sztabka miedzi", 1 } } },
        { "Komora spalania", new() { { "Sztabka żelaza", 1 }, { "Sztabka krzemu", 1 } } },

        // Produkty – komputer pokładowy
        { "Płyta główna", new() { { "Sztabka krzemu", 2 }, { "Sztabka miedzi", 1 } } },
        { "Moduł pamięci", new() { { "Sztabka krzemu", 1 }, { "Plastik", 1 } } },

        // Produkty – zbiornik paliwa
        { "Stal konstrukcyjna", new() { { "Sztabka żelaza", 2 }, { "Kompozyt węglowy", 1 } } },
        { "Powłoka antykorozyjna", new() { { "Plastik", 1 }, { "Sztabka litu", 1 } } },

        // Produkty – kadłub rakiety
        { "Panel kompozytowy", new() { { "Kompozyt węglowy", 1 }, { "Sztabka krzemu", 1 } } },
        { "Stelaż wewnętrzny", new() { { "Sztabka żelaza", 1 }, { "Plastik", 1 } } },

        // Komponenty zaawansowane
        { "Napęd rakietowy", new() { { "Silnik główny", 1 }, { "Komora spalania", 1 } } },
        { "Komputer pokładowy", new() { { "Płyta główna", 1 }, { "Moduł pamięci", 1 } } },
        { "Zbiornik paliwa", new() { { "Stal konstrukcyjna", 1 }, { "Powłoka antykorozyjna", 1 } } },
        { "Kadłub rakiety", new() { { "Panel kompozytowy", 1 }, { "Stelaż wewnętrzny", 1 } } },

        // Produkt końcowy
        { "Rakieta kosmiczna", new()
            {
                { "Napęd rakietowy", 1 },
                { "Komputer pokładowy", 1 },
                { "Zbiornik paliwa", 1 },
                { "Kadłub rakiety", 1 }
            }
        }
    };

    public static Dictionary<string, int>? GetRecipe(string materialName) =>
        Recipes.TryGetValue(materialName, out var recipe) ? recipe : null;
}