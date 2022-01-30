<!--
// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//
-->

<template>
    <header>
        <nav class="navbar navbar-expand-md navbar-dark bg-dark">
            <div class="container-fluid">
                <router-link :to="{ name: 'post' }" custom v-slot="{ href, route, navigate }">
                    <a class="navbar-brand" :href="href" @click="navigate">Pastebin</a>
                </router-link> 
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarCollapse" aria-controls="navbarCollapse" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarCollapse">
                    <ul class="navbar-nav mr-auto">
                        <router-link v-for="mainLink in mainLinks" v-bind:key="mainLink.key" v-bind:to="{ name: mainLink.route }" custom v-slot="{ href, route, navigate, isActive }">
                            <li class="nav-item" v-bind:class="{ active: isActive }">
                                <a class="nav-link" :href="href" @click="navigate">{{ mainLink.title }}</a>
                            </li>
                        </router-link>
                    </ul>
                </div>
            </div>
        </nav>
    </header>
</template>

<script>
    export default {
        data: function () {
            return {
                actions: [
                    {
                        key: 'post',
                        title: 'Post',
                        route: 'post',
                        position: 'main'
                    },
                    {
                        key: 'recent-pastes',
                        title: 'Recent pastes',
                        route: 'recent-pastes',
                        position: 'main'
                    },
                    {
                        key: 'api-help',
                        title: 'API',
                        route: 'api-help',
                        position: 'main'
                    }
                ]
            };
        },
        computed: {           
            mainLinks() {
                return this.getLinks('main');
            },
            routes() {
                return this.$router.options.routes;
            }
        },
        methods: {
            getLinks: function (position) {
                const result = [];
                for (let action of this.actions) {
                    if (this.match(action, position)) {
                        result.push({
                            key: action.key,
                            title: action.title,
                            route: action.route
                        });
                    }
                }
                return result;
            },

            match: function (action, position) {
                if (action.position !== position) {
                    return false;  // Position passt nicht
                }
                if (!this.routes.find(o => o.name === action.route)) {
                    return false;  // Route nicht gefunden
                }
                return true;
            }
        }
    }
</script>

<style scoped>
    header {
        margin-bottom: 1em;
    }
</style>