<template>
  <div class="product-list">
    <table class="products-table">
      <tr>
        <th>Название</th>
        <th>Цена</th>
      </tr>
      <tr v-for="product in getAllProducts" :key="product.id" @click="selectItem(product)">
        <td id="productId" hidden>{{product.id}}</td>
        <td data-th="Название">{{product.name}}</td>
        <td data-th="Цена">{{product.price}}</td>
      </tr>
    </table>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
export default {
  name: "ProductList",
  data() {
    return {
      currentProduct: {}
    };
  },
  computed: {
    ...mapGetters(["getAllProducts"]),
    },
  methods: {
    ...mapActions(["fetchProducts"]),
    selectItem(selectedProduct) {
      this.currentProduct = selectedProduct;
      this.$emit("inputData", this.currentProduct);
    }
  },
  async mounted() {
    this.fetchProducts();
  }
}
</script>

<style lang="less">
.product-list {
  background: #ffffff;
  min-width: 360px;
  margin-left: 2%;
  padding: 15px;
  text-align: center;
  box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24);
  .products-table {
    border-collapse: collapse;
    margin: auto;
    padding: 5px;
    width: 100%;
    animation: float 5s infinite;
    th {
      color: #ffffff;
      background: #43a047;
      border-bottom: 4px solid #f2f2f2;
      border-right: 1px solid #343a45;
      font-size: 20px;
      font-weight: 100;
      padding: 24px;
      text-align: left;
      text-shadow: 0 1px 1px rgba(0, 0, 0, 0.1);
      vertical-align: middle;
      &:first-child {
        border-top-left-radius: 3px;
      }
      &:last-child {
        border-top-right-radius: 3px;
        border-right: none;
      }
    }
    tr {
      border-top: 1px solid #c1c3d1;
      border-bottom: 1px solid #c1c3d1;
      color: #666b85;
      font-size: 16px;
      font-weight: normal;
      text-shadow: 0 1px 1px rgba(256, 256, 256, 0.1);
      &:hover {
        td {
          background: #4caf50 + 15%;
          color: #ffffff;
          border-top: 1px solid #22262e;
        }
      }
      &:first-child {
        border-top: none;
      }
      &:last-child {
        border-bottom: none;
      }
      &:nth-child(odd) {
        td {
          background: #ebebeb;
        }
        &:hover {
          td {
            background: #4caf50;
          }
        }
      }
      &:last-child {
        td {
          &:first-child {
            border-bottom-left-radius: 3px;
          }
          &:last-child {
            border-bottom-right-radius: 3px;
          }
        }
      }
    }
    td {
      background: #ffffff;
      padding: 20px;
      text-align: left;
      vertical-align: middle;
      font-weight: 300;
      font-size: 18px;
      text-shadow: -1px -1px 1px rgba(0, 0, 0, 0.1);
      border-right: 1px solid #c1c3d1;
      &:last-child {
        border-right: 0px;
      }
    }
  }
}
</style>