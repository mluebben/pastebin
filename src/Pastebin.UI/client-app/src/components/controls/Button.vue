<!--
// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//
-->

<script lang="ts">
export default {
  inheritAttrs: false
}
</script>

<script setup lang="ts">
import { ref, computed, useAttrs } from 'vue';
import Icon from '../../components/controls/Icon.vue'

const props = defineProps({
    disabled: {
        type: Boolean,
        default: false
    }
})

const attrs = useAttrs()

const omitEvents = (events: object, toOmit: string[]) => {
  const newEvents: object = {};

  Object.keys(events).forEach((eventName) => {
    if (toOmit.indexOf(String(eventName)) === -1) {
      newEvents[eventName] = events[eventName];
    }
  });

  return newEvents;
};

const button = ref(null)
const isWorking = ref(false)
const isDisabled = computed(() => {
    if (isWorking.value) {
        return true
    }
    if (props.disabled) {
        return true
    }
    return false
})

function click() {
    button.value.click()
}

function onClick(event: MouseEvent) {
    return new Promise((resolve, reject) => {
        isWorking.value = true
        emitClick(event)
            .then(result => {
                isWorking.value = false
                resolve(result)
            })
            .catch(err => {
                isWorking.value = false
                reject(err)
            })
    })
}

function emitClick(event: MouseEvent) {
    const clickListener: any = attrs.onClick
    if (!clickListener) {
        Promise.resolve(false)  // No listener defined
    }

    const result = clickListener(event)
    if (result instanceof Promise) {
        return result  // Listener result is already a promise so return it
    } else {
        return Promise.resolve(result)  // Listener result is not a promise, therefore wrap it in a promise
    }
}
</script>

<template>
    <button class="btn" :class="{ disabled: isDisabled }" type="button" @click="onClick" v-bind="omitEvents($attrs, ['onClick'])" ref="button">
        <Icon v-if="isWorking">
            <div class="loader"></div>
        </Icon>
        <slot></slot>
    </button>
</template>

<style scoped>
    .loader {
        position: relative;
        top: .125em;
        display: inline-block;
        margin-top: auto;
        margin-left: auto;
        margin-bottom: auto;
        margin-right: 0.5em;
        text-indent: -9999em;
        border-top: 0.2em solid rgba(255, 255, 255, 0.2);
        border-right: 0.2em solid rgba(255, 255, 255, 0.2);
        border-bottom: 0.2em solid rgba(255, 255, 255, 0.2);
        border-left: 0.2em solid #ffffff;
        border-radius: 50%;
        -webkit-transform: translateZ(0);
        -ms-transform: translateZ(0);
        transform: translateZ(0);
        -webkit-animation: load8 1.1s infinite linear;
        animation: load8 1.1s infinite linear;
    }

    @-webkit-keyframes load8 {
        0% {
            -webkit-transform: rotate(0deg);
            transform: rotate(0deg);
        }

        100% {
            -webkit-transform: rotate(360deg);
            transform: rotate(360deg);
        }
    }

    @keyframes load8 {
        0% {
            -webkit-transform: rotate(0deg);
            transform: rotate(0deg);
        }

        100% {
            -webkit-transform: rotate(360deg);
            transform: rotate(360deg);
        }
    }
</style>