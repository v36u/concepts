# Theory

Here I'll note down curiosities and answers I found that do not require a project. This is why this directory is called "theory": it is only arbitrary text.

## Table of contents

- [1. yaml vs yml](#1-yaml-vs-yml)
  - [Definition of YAML](#definition-of-yaml)
  - [Answer](#answer)

*Generated with [bitdowntoc](https://github.com/derlin/bitdowntoc)*

## 1. yaml vs yml

### Definition of YAML

> YAML (a recursive acronym for “YAML Ain’t Markup Language”) is a data serialization language designed to be human-friendly and work well with modern programming languages for common everyday tasks. [...]
>
> Open, interoperable and readily understandable tools have advanced computing immensely. YAML was designed from the start to be useful and friendly to people working with data. It uses Unicode printable characters, some of which provide structural information and the rest containing the data itself. YAML achieves a unique cleanness by minimizing the amount of structural characters and allowing the data to show itself in a natural and meaningful way. For example, indentation may be used for structure, colons separate key/value pairs and dashes are used to create “bulleted” lists.

Source: [YAML 1.2.2 spec](https://yaml.org/spec/1.2.2/#chapter-1-introduction-to-yaml)

### Answer

> The "yaml" filename extension is the preferred one; it is the most popular and widely used on the web. The "yml" filename extension is still used. The simultaneous usage of two filename extensions in the same context might cause interoperability issues (e.g., when both a "config.yaml" and a "config.yml" are present).

Source: [RFC 9512](https://datatracker.ietf.org/doc/html/rfc9512#name-filename-extension)

So, it seems that "yml" is just the legacy version. There is no functional difference, and "yaml" is the preferred version across the industry.
