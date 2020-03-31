<template>
  <div id="app">
    <img src="./assets/logo.png">
    <h2>{{ title }}</h2>
    <button v-on:click="fetchData">Start App</button>
    <p>{{ data }}</p>
  </div>
</template>

<script>
  export default {
    name: 'app',
    data() {
      return {
        title: 'Dorfverwaltung',
        data: '',
      }
    },

    methods: {
      fetchData() {
        this.$http.get('https://localhost:5019/Dwarf')
          .then(resp => resp.text())
          .then(text => this.data = text);
      }
    }
  }
</script>

<style>
  #app {
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    margin-top: 60px;
  }

  h1, h2 {
    font-weight: normal;
  }

  button, p {
    font-size: 1.2rem;
  }

  ul {
    list-style-type: none;
    padding: 0;
  }

  li {
    display: inline-block;
    margin: 0 10px;
  }

  a {
    color: #42b983;
  }

  button {
    padding: 15px 30px;
    border-radius: 5px;
    background-color: #35495e;
    color: #fff;
    outline: none;
  }
</style>

