<template>
    <div class="form-container">
    <form class="add-product-form">
        <input type="text" name="product-name" placeholder="Введите название товара">
        <input type="number" name="product-cost" placeholder="Цена">
        <button>Добавить</button>
        <button>Удалить</button>
        <button>Обновить</button>
    </form>
    </div>
</template>

<script>
export default {
    
}
</script>

<style lang="less">
.add-product-form {
  display: flex;
  flex-direction: column;
  max-width: 360px;
  margin: 0 auto 100px;
  padding: 45px;
  text-align: center;
  box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24);
  background: #FFFFFF;
  input {
    outline: 0;
    background: #f2f2f2;
    width: 100%;
    border: 0;
    margin: 0 0 15px;
    padding: 15px;
    box-sizing: border-box;
    font-size: 14px;
  }
  button {
    text-transform: uppercase;
    outline: 0;
    background: #4CAF50;
    width: 100%;
    border: 0;
    padding: 15px;
    color: #FFFFFF;
    font-size: 14px;
    -webkit-transition: all 0.3 ease;
    transition: all 0.3 ease;
    cursor: pointer;
      &:hover,&:active,&:focus {
        background: #43A047;
      }
  }
  .message {
    font-size: 14px;
    text-align: left;
  }
}
</style>