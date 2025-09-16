# Template léger - recherche

# Point d’entrée

`Program.cs` fonctionne comme **point d’entrée** de l’application. Il fournit la configuration de base et établit la connexion à la base de données.

---

# `appsettings.json`

Ce fichier configure la **chaîne de connexion**, c’est-à-dire qu’il précise à quelle base de données l’application va se connecter.
On définit également ici le préfixe URL de l’application ("UrlPrefix").

---

# Pages

- `_ViewImports.cshtml` configure les **@tagHelpers** de .NET, ce qui nous permet d’utiliser des `SelectListItems` avec des **balises côté serveur, conscientes de C#** telles que `asp-for` et `asp-items`. C’est un **sucre syntaxique** qui permet à C# d’itérer automatiquement sur les listes `SelectList` dans les pages `.cshtml`.  
- `Index.cshtml` définit la **page d’accueil**, celle qui se charge en premier lorsque l’on navigue vers l’application.  Dans nos exemples, cette page est généralement utilisée uniquement pour **rediriger vers la véritable première page**.
- `Search.cshtml` est la **page de recherche**.  
- `Results.cshtml` est la **page des résultats**.

Cette application utilise le **pattern PRG** (*Post-Redirect-Get*), ce qui signifie que la page `Results` est chargée via une **action Redirect**. Cela permet de charger cette page via une requête HTTP GET au lieu d’un POST, ce qui signifie que la page peut être **rafraîchie dans le navigateur sans renvoyer le formulaire**.

---

# Modèles (`/Models`)

Ici se trouvent les **modèles** qui représentent les entités manipulées depuis la base de données. Cela permet de **spécifier les types** (`int`, `string`, etc.) et les **noms des valeurs**. Ces modèles sont ensuite importés dans les fichiers `.cshtml.cs` (*code-behind*).

---

# Code-behind (`.cshtml.cs`)

Les **valeurs publiques** déclarées ici et initialisées dans les méthodes `OnGet` ou `OnPost` déterminent les valeurs disponibles dans la page `.cshtml` en tant que **model values**.  
Ces fichiers définissent également **comment récupérer les données depuis la base** lorsque la page se charge.

---

# Données (`/Data`)

Le fichier `AppDbContext.cs` définit la **structure de notre `_context`**, qui représente essentiellement l’objet base de données.  
`AppDbContext` est ensuite **enregistré** dans l’application C# via le fichier `Program.cs`.

---

# `/depot`

C’est ici que **nos bases de données doivent résider**.  
Nous avons un fichier simple stocké ici à titre de démonstration, mais pour votre propre application, vous devez placer une copie de votre **base de données cible** dans une structure de dossiers qui **reproduit celle de l’environnement de production**.  
Sinon, votre **chaîne de connexion sera incorrecte** et devra être modifiée en production.