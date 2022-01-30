<!--
// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//
-->

<script>
    export default {
        mounted() {
            //this.$store.dispatch('fetchVersion')
        },
        computed: {
            productversion() {
                //return this.$store.state.version.productversion
                return { product: 'Pastebin', version: '0.1', 'copyright': 'Copyright (c) 2022 Matthias Lübben', isInitialized: true}
            },
            product() {
                return this.productversion.product
            },
            version() {
                return this.productversion.version
            },
            copyright() {
                return this.productversion.copyright
            },
            isInitialized() {
                return this.productversion.isInitialized
            }
        }
    }
</script>

<template>
    <footer class="footer mt-auto py-3 bg-light">
        <div class="container">
            <!--
            <div class="row">
                <hr class="col mb-2" />
            </div>
            -->
            <div class="row">
                <div class="col footer-content">
                    <p v-if="isInitialized" class="text-muted small">
                        <router-link :to="{ name: 'version' }" custom v-slot="{ href, route, navigate }">
                            <a class="text-muted" :href="href" @click="navigate">{{ product }} {{ version }}</a>
                        </router-link>
                        &middot; {{ copyright }}
                    </p>
                </div>
            </div>
            

<!--
<span class="text-muted">Test for sticky footer</span>
-->

        </div>
    </footer>
</template>

<style scoped>
    .footer-content {
        padding-left: 0;
        padding-right: 0;
    }
</style>
