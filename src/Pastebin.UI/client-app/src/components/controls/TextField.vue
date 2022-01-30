<!--
// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//
-->

<script setup>
import { ref } from 'vue'

const props = defineProps({
    id: String,
    label: String,
    modelValue: String,
    readonly: Boolean,
    state: {
        validator: prop => typeof prop === 'boolean' || prop === null
    },
    errors: Array
})

const emit = defineEmits([
    'update:modelValue',
    'keyup'
])

const field = ref(null)

function onInput() {
    const element = field.value
    const value = element.value
    emit('update:modelValue', value)
}

function onKeyup(event) {
    emit('keyup', event)
}
</script>

<template>
    <div class="form-group">
        <label :for="id">{{ label }}</label>
        <input type="text" class="form-control" :value="modelValue" @input="onInput" @keyup="onKeyup" :readonly="readonly" v-bind:class="{ 'is-valid': state === true, 'is-invalid': state === false }" :id="id" ref="field" />
        <div class="invalid-tooltip">
            <div v-for="error in errors" :key="error">{{ error }}</div>
        </div>
    </div>
</template>