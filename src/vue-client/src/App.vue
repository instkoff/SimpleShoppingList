<template>
  <div id="app" class="container">
    <ProductDetails :currentProduct="selectedProduct" />
    <ProductList @inputData="updateSelectedProduct" />
  </div>
</template>

<script>
import ProductList from '@/components/ProductList'
import ProductDetails from '@/components/ProductDetails'
export default {
  name: 'App',
  components: {
    ProductList,
    ProductDetails
  },
  data: function() {
    return {
      selectedProduct: {}
    };
  },
  methods: {
    updateSelectedProduct(currentProduct) {
      this.selectedProduct = currentProduct;
    }
  }
};
</script>

<style lang="less">
@import (css) url('https://fonts.googleapis.com/css2?family=Poppins&display=swap');
body {
  font-family: 'Poppins', sans-serif;
  font-style: normal;
  font-weight: normal;
  font-size: 13px;
  line-height: 19px;
  letter-spacing: 0.01em;
  background: #76b852; /* fallback for old browsers */
  background: -webkit-linear-gradient(right, #76b852, #8DC26F);
  background: -moz-linear-gradient(right, #76b852, #8DC26F);
  background: -o-linear-gradient(right, #76b852, #8DC26F);
  background: linear-gradient(to left, #76b852, #8DC26F);
}

.main {
  width: 85%;
  height: 100%;
  margin: 0 auto;
  .container {
    display: flex;
    justify-content: center;
    align-items: flex-start;
    padding:10px;
  }
}
</style>
