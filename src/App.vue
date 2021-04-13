<template>
  <div id="app" class="bg-gray-800">
    <title-bar></title-bar>
    <router-view id="router"> </router-view>
  </div>
</template>

<script>
import TitleBar from "./components/TitleBar.vue";

export default {
  name: "App",
  components: {
    TitleBar,
  },
};
</script>

<style lang="scss">
body,
html {
  background: transparent;
  font-family: "Nunito" !important;
}
#app {
  border-radius: 16px;
  width: 98vw;
  height: 98vh;
  margin: 1vh 1vw;
  box-shadow: 0 2px 5px rgba(0, 0, 0, 0.21), 0 2px 5px rgba(0, 0, 0, 0.25);
}
#router {
  padding: 0 24px;
}
</style>
