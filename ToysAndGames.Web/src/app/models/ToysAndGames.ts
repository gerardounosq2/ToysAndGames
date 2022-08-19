export interface ToysAndGames {
    id: number,
    name: string,
    description: string,
    ageRestriction: number,
    price: number,
    companyName: string
}

export interface ToysAndGamesInput {
    name: string,
    description: string,
    age: number,
    price: number,
    companyid: number
}