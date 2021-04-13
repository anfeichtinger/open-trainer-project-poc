<template>
  <div
    class="px-4 flex justify-between bg-grey-800 h-16"
    style="-webkit-app-region: drag"
  >
    <ul class="flex items-center">
      <li class="h-10 w-10">
        <img
          class="h-full w-full mx-auto"
          src="@/assets/svg/logo.svg"
          alt="Logo"
        />
      </li>
      <li class="text-gray-200 px-4 font-bold">
        Open Trainer Project
      </li>
    </ul>
    <ul class="m-4 h-8 w-8">
      <li>
        <button @click="quit()" class="close-btn mx-8 my-6"></button>
      </li>
    </ul>
  </div>
</template>

<script lang="ts">
import { ipcRenderer } from "electron";

export default {
  name: "TitleBar",
  methods: {
    quit: function() {
      ipcRenderer.sendSync("close-app");
    },
  },
};
</script>

<style lang="scss" scoped>
.close-btn {
  display: block;
  position: fixed;
  right: 0;
  top: 0;
  width: 28px;
  height: 28px;
  transition: transform 0.25s ease-in-out;
  -webkit-app-region: no-drag;
  outline: none;
}
.close-btn:hover {
  transform: rotate(90deg);
}
.close-btn:before {
  content: "";
  position: absolute;
  display: block;
  margin: auto;
  left: 0;
  right: 0;
  top: 0;
  bottom: 0;
  width: 20px;
  height: 0;
  border-top: 4px solid #ed1e79;
  transform: rotate(45deg);
  transform-origin: center;
  border-radius: 4px;
}
.close-btn:after {
  content: "";
  position: absolute;
  display: block;
  margin: auto;
  left: 0;
  right: 0;
  top: 0;
  bottom: 0;
  width: 20px;
  height: 0;
  border-top: 4px solid #ed1e79;
  transform: rotate(-45deg);
  transform-origin: center;
  border-radius: 4px;
}
</style>
