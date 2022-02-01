<!--
// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//
-->

<script setup>
import { ref, computed } from 'vue'

const props = defineProps({
    id: String,
    label: String,
    modelValue: {
        validator(prop) {
            return typeof prop === 'number' || typeof prop === 'string' || prop === null
        }
    },
    readonly: Boolean,
    disabled: {
        type: Boolean,
        default: false
    },
    items: Array,
    state: {
        validator(prop) {
            return typeof prop === 'boolean' || prop === null
        }
    },
    errors: Array
})

const emit = defineEmits([
    'update:modelValue'
])

const field = ref(null)

const selectedItem = computed(() => { 
    const item = findItem(props.modelValue)
    if (item != null) {
        return item
    }

    return {
        value: '',
        label: '',
        item: null
    }
})

function onChange() {
    const element = field.value
    const value = element.value

    const item = findItem(value)
    if ('item' in item) {
        emit('update:modelValue', item.item)
    } else {
        emit('update:modelValue', value)
    }
}

function findItem(value) {
    const itemByItemProperty = props.items.find(o => o.item === value)
    if (itemByItemProperty != null) {
        return itemByItemProperty
    }

    const itemByValueProperty = props.items.find(o => o.value === value)
    if (itemByValueProperty != null) {
        return itemByValueProperty
    }

    return null
}

</script>

<template>
    <div class="form-group">
        <label :for="id">{{ label }}</label>
        <select class="form-select custom-select" :value="selectedItem.value" @change="onChange" :readonly="readonly" :disabled="disabled" v-bind:class="{ 'is-valid': state === true, 'is-invalid': state === false }" :id="id" ref="field">
            <option v-for="item in items" :key="item.value" :value="item.value">{{ item.label }}</option>
        </select>
        <div class="invalid-tooltip">
            <div v-for="error in errors" :key="error">{{ error }}</div>
        </div>
    </div>
</template>