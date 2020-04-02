<template>
  <transition name="animateit" appear>
    <div id="app" v-show="true">
      <h1>{{ title }}</h1>
      <img ref="vueLogo" src="./assets/logo.png">
      <div></div>
      <transition name="animateit" mode="out-in">
        <!-- Tribe Cards -->
        <button v-on:click="fetchData" v-if="displayBtn">Stämme</button>
        <app-tribe
          v-if="displayTribes"
          v-bind:tribeList="tribes"
          v-on:showDwarfs="getDwarfs"
        />
        <app-dwarf
          v-if="displayDwarfs"
          v-bind:tribeName="tribeName"
          v-bind:dwarfs="dwarfsInTribe"
          v-on:backBtn="goToTribes"
        />
      </transition>
    </div>
  </transition>
</template>

<script>
  import Tribe from './component/Tribe.vue';
  import Dwarf from './component/Dwarf.vue';

  export default {
    name: 'app',
    data() {
      return {
        title: 'Dorfverwaltung',
        dwarfs: [],
        tribes: [],
        dwarfsInTribe: [],
        tribeName: '',
        displayBtn: true,
        displayTribes: false,
        displayDwarfs: false,
      }
    },

    components: {
      appTribe: Tribe,
      appDwarf: Dwarf,
    },

    methods: {
      // Receive Data From Backend :
      fetchData() {
        this.$refs.vueLogo.className = "cool-logo";
        this.displayBtn = false;
        this.displayTribes = true;
        this.$http.get('https://localhost:5019/')
          .then(resp => resp.json()) // Make a JSON File from Server-Response.
          .then(data => data.forEach(dwarf => {
            this.dwarfs.push(dwarf); // Add received data to dwarfs-array

            let alreadyStoredTribe = this.tribes.find(tribe => tribe.name === dwarf['tribe']['name']);
            // If the tribe is not already stored, store it into the tibes-array :
            if (!alreadyStoredTribe) {
              this.tribes.push({...dwarf['tribe'], tax: +dwarf['powerFactor'] * 2125})
            } else {
              // If the tribe is already stored just increment the tax by dwarf's powerFactor times 2125 :
              alreadyStoredTribe.tax += +dwarf['powerFactor'] * 2125
            }
          }))
          .catch(e => console.log(e));
      },

      getDwarfs(event) {
        this.$refs.vueLogo.className = 'cool-logo-2';
        this.displayTribes = false;
        this.displayDwarfs = true;
        this.tribeName = event.target.parentElement.firstChild.textContent;
        this.dwarfsInTribe = this.dwarfs.filter(dwarf => dwarf.tribe.name === this.tribeName);
      },

      goToTribes() {
        this.displayBtn = false;
        this.displayDwarfs = false;
        this.displayTribes = true;
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

  button, p, a {
    font-size: 1.2rem;
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

  .animateit-enter {
    opacity: 0;
  }

  .animateit-enter-active {
    transition: opacity 0.7s;
  }

  .animateit-leave {
  }

  .animateit-leave-active {
    transition: opacity 0.7s;
    opacity: 0;
  }

  .cool-logo {
    animation: cool-rotate 1.7s forwards;
  }

  .cool-logo-2 {
    animation: cool-rotate-2 1.7s forwards;
  }

  @keyframes cool-rotate {
    from {
      transform: rotate3d(0);
    }
    to {
      transform: rotate3d(0, 1, 0, 180deg);
    }
  }

  @keyframes cool-rotate-2 {
    from {
      transform: rotate3d(0);
    }
    to {
      transform: rotate3d(1, 0, 0, 180deg);
    }
  }
</style>

