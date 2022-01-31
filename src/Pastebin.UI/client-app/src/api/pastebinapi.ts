// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

import axios from 'axios'

interface CreatePasteRequest {
    title: string,
    retention: number,
    language: string,
    code: string
}

interface CreatePasteResult {
    id: string
}

async function post({ title, retention, language, code }: CreatePasteRequest): Promise<CreatePasteResult> {
    const response = await axios.post('/api/pastes', {
        title,
        retention,
        language,
        code
    })

    const result = response.data
    return result
}

interface GetRecentPastesResult {
    id: string,
    title: string,
    language: string,
    code: string,
    creationDate: string,
    expirationDate: string
}

async function getRecentPastes(): Promise<GetRecentPastesResult[]> {

    console.log('get recent pastes')

    const response = await axios.get('/api/pastes')
    const result = response.data

    console.log('get request result: ', result)

    return result.pastes.map(o => ({
        id: o.id,
        title: o.title,
        language: o.language,
        code: o.code,
        creationDate: o.creationDate,
        expirationDate: o.expirationDate
    }))
}


interface GetByIdResult {
    id: string,
    title: string,
    language: string,
    code: string,
    expirationDate: string
}

/**
 * 
 * @param {string} id 
 * @returns 
 */
async function getPasteById(id: string): Promise<GetByIdResult> {
    console.log('get pastebin: ', id)

    const response = await axios.get('/api/pastes/' + id)
    const result = response.data

    console.log('get request result: ', result)


    const obj = {
        id: result.id,
        title: result.title,
        language: result.language,
        code: result.code,
        expirationDate: result.expirationDate
    }

    console.log('obj: ', obj)

    return obj
}



export default {
    post,
    getRecentPastes,
    getPasteById
}