<template>
  <transition name="animateit" appear>
    <div id="app" v-show="true">
      <h1>{{ title }}</h1>
      <img ref="vueLogo" alt="vue rules" src="./assets/logo.png">
      <transition name="animateit" mode="out-in">

        <!-- In der Start.vue Komponente werden die Daten vom Backend geholt -->
        <app-start
          v-if="displayStartBtn"
          v-on:clicked="startApp"
          v-bind:dwarfs="dwarfs"
          v-bind:tribes="tribes"
        />

        <!-- In dieser Komponente werden die Stämme aufgelistet -->
        <app-tribe
          v-if="displayTribes"
          v-bind:tribeList="tribes"
          v-on:showDwarfs="getDwarfs"
        />

        <!-- In der Folgende Komponente werden die Zwerge kategorisiert nach dem Stamm aufgelistet -->
        <app-dwarf
          v-if="displayDwarfs"
          v-bind:tribeName="tribeName"
          v-bind:dwarfs="dwarfsInTribe"
          v-on:backBtn="goToTribes"
          v-on:weaponAdded="reloadApp"
        />
      </transition>
    </div>
  </transition>
</template>

<script>
  import Start from './component/Start.vue';
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
        displayStartBtn: true,
        displayTribes: false,
        displayDwarfs: false,
      }
    },

    components: {
      appTribe: Tribe,
      appDwarf: Dwarf,
      appStart: Start,
    },

    methods: {
      startApp() {
        this.$refs.vueLogo.className = "cool-logo";
        this.displayStartBtn = false;
        this.displayTribes = true;
      },

      getDwarfs(event) {
        this.$refs.vueLogo.className = 'cool-logo-2';
        this.displayTribes = false;
        this.displayDwarfs = true;
        this.tribeName = event.target.parentElement.firstChild.textContent;
        this.dwarfsInTribe = this.dwarfs.filter(dwarf => dwarf.tribe.name === this.tribeName);
      },

      goToTribes() {
        this.displayStartBtn = false;
        this.displayDwarfs = false;
        this.displayTribes = true;
        this.$refs.vueLogo.className = 'cool-logo-back';
      },

      reloadApp() {
        alert('Waffe erfolgreich hinzugefügt');
        location.reload();
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
    cursor: pointer;
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

  .cool-logo-back {
    animation: cool-rotate-back 1.7s forwards;
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

  @keyframes cool-rotate-back {
    from {
      transform: rotate3d(1, 0, 0, 180deg);
    }
    to {
      transform: rotate3d(0, 1, 0, 0deg);
    }
  }
</style>

