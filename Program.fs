// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from Sarab"
// Define Coach record
type Coach = {
    Name: string
    FormerPlayer: bool
}

// Define Stats record
type Stats = {
    Wins: int
    Losses: int
}

// Define Team record
type Team = {
    Name: string
    Coach: Coach
    Stats: Stats
}

// Define coaches
let rickCarlisle = { Name = "Rick Carlisle"; FormerPlayer = false }
let tyronnLue = { Name = "Tyronn Lue"; FormerPlayer = false }
let darvinHam = { Name = "Darvin Ham"; FormerPlayer = false }
let taylorJenkins = { Name = "Taylor Jenkins"; FormerPlayer = false }
let erikSpoelstra = { Name = "Erik Spoelstra"; FormerPlayer = false }

// Define stats
let atlantaHawksStats = { Wins = 3; Losses = 0 }
let losAngelesLakersStats = { Wins = 2; Losses = 0 }
let bostonCelticsStats = { Wins = 1; Losses = 0 }
let brooklynNetsStats = { Wins = 1; Losses = 0 }
let portlandTrailBlazersStats = { Wins = 1; Losses = 0 }

// Define teams
let atlantaHawks = { Name = "Atlanta Hawks"; Coach = rickCarlisle; Stats = atlantaHawksStats }
let losAngelesLakers = { Name = "Los Angeles Lakers"; Coach = tyronnLue; Stats = losAngelesLakersStats }
let bostonCeltics = { Name = "Boston Celtics"; Coach = darvinHam; Stats = bostonCelticsStats }
let brooklynNets = { Name = "Brooklyn Nets"; Coach = taylorJenkins; Stats = brooklynNetsStats }
let portlandTrailBlazers = { Name = "Portland Trail Blazers"; Coach = erikSpoelstra; Stats = portlandTrailBlazersStats }

// Create a list of teams
let teams = [atlantaHawks; losAngelesLakers; bostonCeltics; brooklynNets; portlandTrailBlazers]

// Filter successful teams
let successfulTeams = teams |> List.filter (fun team -> team.Stats.Wins > team.Stats.Losses)

// Calculate success percentage
let calculateSuccessPercentage (team: Team) =
    let totalGames = float (team.Stats.Wins + team.Stats.Losses)
    (float team.Stats.Wins) / totalGames * 100.0

// Calculate success percentage for all teams
let successPercentages = successfulTeams |> List.map calculateSuccessPercentage

// Print success percentages
printfn "Success percentages and Coaches:"
List.iter2 (fun team percentage -> printfn "%s (Coach: %s): %.2f%%" team.Name team.Coach.Name percentage) successfulTeams successPercentages















// Define Cuisine discriminated union
type Cuisine =
    | Korean
    | Turkish

// Define MovieType discriminated union
type MovieType =
    | Regular
    | IMAX
    | DBOX
    | RegularWithSnacks
    | IMAXWithSnacks
    | DBOXWithSnacks

// Define Activity discriminated union
type Activity =
    | BoardGame
    | Chill
    | Movie of MovieType
    | Restaurant of Cuisine
    | LongDrive of int * float

// Function to calculate the budget for an activity
let calculateBudget (activity: Activity) =
    match activity with
    | BoardGame -> 0.0
    | Chill -> 0.0
    | Movie movieType ->
        match movieType with
        | Regular -> 12.0
        | IMAX -> 17.0
        | DBOX -> 20.0
        | RegularWithSnacks -> 12.0 + 5.0
        | IMAXWithSnacks -> 17.0 + 5.0
        | DBOXWithSnacks -> 20.0 + 5.0
    | Restaurant cuisine ->
        match cuisine with
        | Korean -> 70.0
        | Turkish -> 65.0
    | LongDrive (kilometers, fuelChargePerKilometer) ->
        float kilometers * fuelChargePerKilometer

// Example usage
let activity1 = Movie Regular
let activity2 = Restaurant Korean
let activity3 = LongDrive (100, 0.05)

printfn "Budget for activity 1: %.2f CAD" (calculateBudget activity1)
printfn "Budget for activity 2: %.2f CAD" (calculateBudget activity2)
printfn "Budget for activity 3: %.2f CAD" (calculateBudget activity3)