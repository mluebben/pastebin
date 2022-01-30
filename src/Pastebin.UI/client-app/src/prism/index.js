// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//

import Prism from 'prismjs'
import Components from 'prismjs/components'

Prism.manual = true


// Import highlighting library (you can use any library you want just return html string)
//import { highlight, languages } from 'prismjs/components/prism-core'
//import loadLanguages from 'prismjs/components/index.js'
//import 'prismjs/components/prism-clike'
//import 'prismjs/components/prism-javascript'
//import 'prismjs/themes/prism-tomorrow.css'
import 'prismjs/themes/prism.css'




function getLanguageKeys(languages) {
  const languageKeys = []
  for (const languageKey in languages) {
    if (languageKey == 'meta') {
      continue
    }
    languageKeys.push(languageKey);
  }

  const result = []
  for (const languageKey of languageKeys) {
    result.push({
      label: languages[languageKey].title,
      value: languageKey
    })
  }

  return result
}


export const languages = getLanguageKeys(Components.languages)

//console.log('languageList: ', languages)




/**
 * Hervorheben von Text.
 * 
 * @param {string} code 
 * @param {string} language 
 * @returns {string}
 */
export function highlight(code, language) {
  const grammer = Prism.languages[language]

  return Prism.highlight(code, grammer, language)
}


//export deflt {
//    highlight,
//    languages
//}