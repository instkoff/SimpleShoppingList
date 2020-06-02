let baseUrl = "http://localhost:5000/api/Product";
export default {
    state: {
        products: []
    },
    getters: {
        getAllProducts(state) {
            return state.products;
        },
    },
    mutations: {
        updateProducts(state, products) {
            state.products = products;
        }
    },
    actions: {
        async fetchProducts(ctx) {
            const result = await fetch(baseUrl+"/get-all-products");
            const productList = await result.json();
            ctx.commit('updateProducts', productList);
        }
    }
}