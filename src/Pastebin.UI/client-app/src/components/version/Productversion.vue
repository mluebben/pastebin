<!--
// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//
-->

<template>
    <container :title="$t('title')">
        <div class="col pt-3 pb-3">
            <p class="product">{{ product }} {{version}}</p>
            <p><span class="text-muted">{{ $t('copyright') }}</span><br/>{{copyright}}</p>
            <p><span class="text-muted">{{ $t('version') }}</span><br/>{{major}}.{{minor}}.{{revision}}</p>
        </div>
    </container>
</template>

<script>
    import Container from '@/components/container/Container.vue'

    export default {
        components: {
            'container': Container
        },
        computed: {
            productversion() {
                return this.$store.state.version.productversion
            },
            product() {
                return this.nz(this.productversion.product)
            },
            version() {
                return this.nz(this.productversion.version)
            },
            copyright() {
                return this.nz(this.productversion.copyright)
            },
            major() {
                return this.nz(this.productversion.major)
            },
            minor() {
                return this.nz(this.productversion.minor)
            },
            revision() {
                return this.nz(this.productversion.revision)
            }
        },
        mounted() {
            this.$store.dispatch('fetchVersion')
        },
        methods: {
            nz(value) {
                return (value === null || value === '') ? 'n/a' : value.toString()
            }
        }
    }
</script>

<style scoped>
    .product {
        font-weight: bold;
        font-size: larger;
    }
</style>

<i18n locale="de">
    {
    "title": "Produkt",
    "copyright": "Copyright:",
    "version": "Version:"
    }
</i18n>

<i18n locale="en">
    {
    "title": "Product",
    "copyright": "Copyright:",
    "version": "Version:"
    }
</i18n>