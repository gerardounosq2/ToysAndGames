import { makeAutoObservable } from "mobx";
import agent from "../app/api/agent";
import { ToysAndGames } from "../app/models/ToysAndGames";

export default class ProductStore {
    loading: boolean = false;
    products: ToysAndGames[] = [];

    constructor() {
        makeAutoObservable(this);
    }

    setLoading = (state: boolean) => this.loading = state;

    getAllProducts = async () => {
        this.setLoading(true);
        try {
            this.products = await agent.Products.getAll();
            this.setLoading(false);
        }
        catch (error) {
            this.setLoading(false);
            throw error;
        }
    }
}