<!--
// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//
-->

<script setup>
// Diese Komponente ermöglicht es svg, img und div-Elemente an der baseline von Text auszurichten.
// https://blog.prototypr.io/align-svg-icons-to-text-and-say-goodbye-to-font-icons-d44b3d7b26b4

const props = defineProps({
    baseline: {
        type: Boolean,
        default: true
    }
})
</script>

<template>
    <span class="icon" :class="{ 'icon-baseline': baseline }"><slot></slot></span>
</template>

<style scoped>
    .icon {
        display: inline-flex;
        align-self: center;
    }

    .icon img,
    .icon svg,
    .icon div {
        height: 1em;
        width: 1em;
    }

    .icon.icon-baseline img,
    .icon.icon-baseline svg,
    .icon.icon-baseline div {
        top: .125em;
        position: relative;
    }

    .icon div {
        display: inline-block;
    }
</style>
