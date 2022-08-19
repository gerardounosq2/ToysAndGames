import { FastField } from "formik";
import { makeAutoObservable, runInAction } from "mobx";
import agent from "../app/api/agent";
import { ToysAndGames, ToysAndGamesInput } from "../app/models/ToysAndGames";

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
            const data = await agent.Products.getAll();
            runInAction(() => {
                data.forEach(p => this.products.push(p));
                this.setLoading(false);
            })
        }
        catch (error) {
            this.setLoading(false);
            throw error;
        }
    }

    deleteProduct = async (id: number) => {
        this.setLoading(true);
        try {
            await agent.Products.delete(id);
            runInAction(() => {
                this.products = [...this.products.filter(p => p.id !== id)];
                this.setLoading(false);
            })
        } catch (error) {
            this.setLoading(false)
            throw error;
        }
    }

    createProduct = async (product: ToysAndGamesInput) => {
        try {
            this.setLoading(true);
            await agent.Products.create(product);
            runInAction(() => {
                // this.products.push(product);
            })
        } catch (error) {
            this.setLoading(false);
            throw error;
        }
    }

    updateProduct = async (id: number, product: ToysAndGamesInput) => {
        try {
            this.setLoading(true);
            await agent.Products.update(id, product);
            runInAction(() => {
                this.products = [...this.products.filter(p => p.id !== id)];
                // this.products.push(product);
                this.setLoading(false);
            })
        } catch (error) {
            this.setLoading(false);
            throw error;
        }
    }
}