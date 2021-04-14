<template>
  <div class="text-gray-200">
    Home
  </div>
</template>

<script lang="ts">
import { ipcRenderer } from "electron";

export default {
  name: "Home",
  created() {
    ipcRenderer.send("register-hotkey", "F1");
    ipcRenderer.on("F1", (event, arg) => {
      console.log(arg);
    });
  },
};
</script>
