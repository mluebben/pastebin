<!--
// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//
-->

<script>
    //import Alerts from '@/components/alerts/Alerts.vue'
    //import Productversion from '@/components/version/Productversion.vue'
    //import Buildversion from '@/components/version/Buildversion.vue'

    export default {
        //components: {
            //'alerts': Alerts,
            //'v-productversion': Productversion,
            //'v-buildversion': Buildversion
        //},
        computed: {
            alerts() {
                //return this.$store.state.Alerts
                return []
            }
        }
    }
</script>

<template>
    <div class="container">
        <!--
        <div class="row">
            <alerts class="col" :alerts="alerts" />
        </div>
        -->
        <div class="row">
            <div class="col-md-6 pr-3 mb-3">
                <div class="row">
                    <!--
                    <v-productversion class="col mr-3" />
                    -->
                </div>
            </div>
            <div class="col-md-6 pr-3 mb-3">
                <div class="row">
                    <!--
                    <v-buildversion class="col mr-3" />
                    -->
                </div>
            </div>
        </div>
    </div>
</template>