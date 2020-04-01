<template>
  <div id="app">
    <img src="./assets/logo.png">
    <h2>{{ title }}</h2>
    <button v-on:click="fetchData" v-bind:disabled="running">Start App</button>
    <app-tribe
      v-if="running"
      v-bind:tribeList="tribes"
      v-on:showDwarfs="getDwarfs"
    />
  </div>
</template>

<script>
  import Tribe from './component/Tribe.vue';

  export default {
    name: 'app',
    data() {
      return {
        title: 'Dorfverwaltung',
        dwarfs: [],
        tribes: [],
        running: false,
      }
    },

    components: {
      appTribe: Tribe,
    },

    methods: {
      fetchData() {
        this.running = true;
        this.$http.get('https://localhost:5019/')
          .then(resp => resp.json())
          .then(data => data.forEach(dwarf => {
            this.dwarfs.push(dwarf);

            let alreadyStoredTribe = this.tribes.find(tribe => tribe.name === dwarf['tribe']['name'])
            if (!alreadyStoredTribe) {
              this.tribes.push({...dwarf['tribe'], tax: +dwarf['powerFactor'] * 2125})
            } else {
              alreadyStoredTribe.tax += +dwarf['powerFactor'] * 2125
            }
          }))
          .catch(e => console.log(e));
      },

      getDwarfs() {

      }
    }
  }
</script>

<style>
  @import url('https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css');

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

  button, p, a {
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

  button, a {
    padding: 12px 24px;
    border-radius: 5px;
    background-color: #35495e;
    color: #fff;
    outline: none;
  }

  a:hover {
    color: white;
    text-decoration: none;
  }
</style>

