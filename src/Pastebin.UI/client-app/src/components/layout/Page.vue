<!--
// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//
-->

<script setup>
    import Header from '@/components/layout/Header.vue'
    import Footer from '@/components/layout/Footer.vue'
</script>

<template>
    <div class="d-flex flex-column min-vh-100">
        <main class="wrapper flex-grow-0">
            <Header />

            <div role="main">
                <slot></slot>
            </div>
        </main>

        <Footer />
    </div>
</template>