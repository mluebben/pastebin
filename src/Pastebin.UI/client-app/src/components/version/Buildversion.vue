<!--
// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//
-->

<template>
    <container :title="$t('title')">
        <div class="col pt-3 pb-3">
            <p><span class="text-muted">{{ $t('version') }}</span><br/>{{ version }}</p>
            <p><span class="text-muted">{{ $t('branch') }}</span><br/>{{ branch }}</p>
            <p><span class="text-muted">{{ $t('commit') }}</span><br/>{{ commit }}</p>
            <p><span class="text-muted">{{ $t('builtAt') }}</span><br/>{{ builtAt }}</p>
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
            buildversion() {
                return this.$store.state.version.buildversion
            },
            version() {
                return this.nz(this.buildversion.version)
            },
            branch() {
                return this.nz(this.buildversion.branch)
            },
            commit() {
                return this.nz(this.buildversion.commit)
            },
            builtAt() {
                return this.nz(this.buildversion.builtAt)
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

<i18n locale="de">
    {
    "title": "Build",
    "version": "Version:",
    "branch": "Branch:",
    "commit": "Commit:",
    "builtAt": "Erstellt am:"
    }
</i18n>

<i18n locale="en">
    {
    "title": "Build",
    "version": "Version:",
    "branch": "Branch:",
    "commit": "Commit:",
    "builtAt": "Built at:"
    }
</i18n>