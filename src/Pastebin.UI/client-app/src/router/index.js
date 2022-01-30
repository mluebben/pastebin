// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

import { createRouter, createWebHashHistory } from 'vue-router'
import Post from '@/views/Post.vue'
import RecentPastes from '@/views/RecentPastes.vue'
import View from '@/views/View.vue'
import ApiHelp from '@/views/ApiHelp.vue'
import Version from '@/views/Version.vue'

const routes = [
    {
        path: '/post',
        alias: '/',
        name: 'post',
        component: Post,
        meta: {
            title: () => 'Post - Paste Bin' //i18n.t('postTitle')
        }
    },
    {
        path: '/recent-pastes',
        name: 'recent-pastes',
        component: RecentPastes,
        meta: {
            title: () => 'Recent pastes - Paste Bin'  //i18n.t('viewTitle')
        }
    },
    {
        path: '/views/:id',
        name: 'view',
        component: View,
        meta: {
            title: () => 'View - Paste Bin'  //i18n.t('viewTitle')
        },
        props: route => {
            console.log('route as string: ', JSON.stringify(route))
            console.log('how does the route look: ', route)
            
            const result =
             {
                id: route.params.id
            }

console.log('passing as props: ', result)

            return result
        }
    },
    {
        path: '/api-help',
        name: 'api-help',
        component: ApiHelp,
        meta: {
            title: () => 'Api Help - Paste Bin'  //i18n.t('viewTitle')
        }
    },
    {
        path: '/version',
        name: 'version',
        component: Version
    }
]

const router = new createRouter({
    linkActiveClass: 'active',
	history: createWebHashHistory(),
    routes
})


async function beforeEach(to, from, next) {
    // This goes through the matched routes from last to first, finding the closest route with a title.
    // eg. if we have /some/deep/nested/route and /some, /deep, and /nested have titles, nested's will be chosen.
    const nearestWithTitle = to.matched.slice().reverse().find(r => r.meta && r.meta.title);

    // If a route with a title was found, set the document (page) title to that value.
    if (nearestWithTitle) {
        document.title = nearestWithTitle.meta.title();
    }

    next();
}

router.beforeEach((to, from, next) => {
    beforeEach(to, from, next)
});

export default router