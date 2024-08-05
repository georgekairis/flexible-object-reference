# Contributing Guidelines

This guide outlines the expectations for all contributors to ensure a collaborative and supportive environment. By following these guidelines, we aim to improve the project together while creating a welcoming space for everyone involved. Adhering to these standards will help ensure a positive experience for both contributors and maintainers.


### Table of Contents

- [Code of Conduct](#code-of-conduct)
- [Asking Questions](#asking-questions)
- [Opening an Issue](#opening-an-issue)
- [Bug Reports & Other Issues](#bug-reports-and-other-issues)
- [Feature Requests](#feature-requests)
- [Triaging Issues](#triaging-issues)
- [Submitting Pull Requests](#submitting-pull-requests)
- [Writing Commit Messages](#writing-commit-messages)
- [Code Review](#code-review)
- [Coding Style](#coding-style)
- [Credits](#credits)




## Code of Conduct

Please review the [Code of Conduct](./CODE_OF_CONDUCT.md). It is in effect at all times and must be honored by everyone who contributes to this project.




## Asking Questions

See the [Support Guide](./SUPPORT.md) for more information. GitHub issues are meant for reporting bugs and requesting features, not for debugging specific project issues.




## Opening an Issue

Before [creating an issue](https://help.github.com/en/github/managing-your-work-on-github/creating-an-issue), ensure you are using the [latest version](https://github.com/georgekairis/flexible-object-reference/releases) of the project. If you are not up-to-date, try updating to see if it resolves your problem.


### Bug Reports and Other Issues

To contribute effectively, submit a detailed issue of the problem you encountered. As a developer, please **provide a ticket that you would like to receive**. We always appreciate a well-written, thorough bug report.

- **Review the [Manual](../README.md#manual) and [Support Guide](./SUPPORT.md)** before opening a new issue.

- **Do not open a duplicate issue.** Search the **[existing issues](https://github.com/georgekairis/flexible-object-reference/issues)** to see if your problem has already been reported. If your issue exists, comment with any additional information you have. Simply noting 'I have this problem too' helps prioritize common issues and requests.

- **Use [reactions](https://github.blog/2016-03-10-add-reactions-to-pull-requests-issues-and-comments/) instead of comments** if you want to "+1" an existing issue.

- **Fully complete the provided issue template.** The template asks for all the information needed to address the issue quickly and efficiently. **Be clear, concise, and descriptive.** Include as much detail as possible, such as steps to reproduce, stack traces, compiler errors, library versions and screenshots (if applicable).

- **Use [GitHub-flavored Markdown](https://help.github.com/en/github/writing-on-github/basic-writing-and-formatting-syntax).** Place code blocks and console outputs in triple backticks (```) for better readability.

- **Please write in English**.


### Feature Requests

Feature requests are welcome! While we will consider all requests, we cannot guarantee that yours will be accepted. We aim to avoid [feature creep](https://en.wikipedia.org/wiki/Feature_creep). Your idea may be great, but could also be out of scope for the project. If accepted, we cannot commit to a specific timeline for implementation or release. However, you are welcome to submit a pull request to contribute!

- **Do not open a duplicate feature request.** Search for **[existing feature requests](https://github.com/georgekairis/flexible-object-reference/issues)** before creating a new one. If you find a similar feature already requested, add a comment to that issue.

- **Fully complete the provided issue template.** The feature request template includes all necessary information to start a productive discussion. **Be specific about the desired outcome of the feature** and how it integrates with existing features. Include implementation details if possible.

- **Please write in English**.




## Triaging Issues

You can help triage issues by reproducing bug reports or requesting additional information, such as version numbers or steps to reproduce the problem. Any assistance you provide to quickly resolve an issue is greatly appreciated!




## Submitting Pull Requests

Before [forking the repo](https://help.github.com/en/github/getting-started-with-github/fork-a-repo) and [creating a pull request](https://help.github.com/en/github/collaborating-with-issues-and-pull-requests/proposing-changes-to-your-work-with-pull-requests), please discuss the changes by creating an issue or by commenting your intended approach for solving the problem in the comments of an existing issue.

> [!NOTE]
> All contributions will be licensed under the project's license.

- **Smaller is better.** Submit **one** pull request per bug fix or feature. A pull request should contain isolated changes pertaining to a single bug fix or feature implementation. **Do NOT refactor or reformat code that is unrelated to your change.** It is better to **submit multiple small pull requests** rather than a single large one. Large pull requests will take more time to review, or may be rejected altogether.

- **Coordinate changes**, it is important that everyone is on the same page. **Always create an issue to discuss the proposed change(s), implementation strategy, and release timeline with the maintainers.** By not doing so, you risk doing a lot of work for nothing. If you want to **contribute to a feature that is being developed by another person**, please leave a comment on that feature's relevant issue and discuss your proposal with the contributors of the feature.

- **Prioritize understanding over cleverness.** Write code clearly and concisely. Remember that source code usually gets written once and read often. **Ensure the code is clear to the reader.** The purpose and logic should be obvious to a reasonably skilled developer, otherwise you should add a comment that explains it.

- **Follow existing coding style and conventions.** Keep your code consistent with the style, formatting, and conventions in the rest of the code base. When possible, these will be enforced with a linter. Consistency makes for easier reviews and modifications in the future.

- **Update the DOCUMENTATION files.** Document your changes in the existing guides.

- **Update the CHANGELOG for all enhancements, bug fixes, and changes you make.** Include the corresponding **issue number** and your **GitHub username** (e.g. "- Fixed crash in profile view. #123 @georgekairis").

- **Use the repo's default and pre-release branches for bug/other fixes.** 

  **Branch from and [submit your pull request](https://help.github.com/en/github/collaborating-with-issues-and-pull-requests/creating-a-pull-request-from-a-fork)** to the **release branch where the bug was discovered**.

  - If the bug was found in the **latest official release**, use the **default branch (`main`).**
  
  - If the bug was found in a **pre-release**, use that **pre-release branch (`release/#.#.#`).**
  
  ***Unless you are a contributor** who has discovered a bug in their own work, **DO NOT create pull requests for bugs and issues in experimental branches**. Instead, [create an issue](#opening-an-issue) and **discuss the problem with the person who introduced it**.

- **Use the repo's experimental branches for contributing features.** 

  **Branch from and [submit your pull request](https://help.github.com/en/github/collaborating-with-issues-and-pull-requests/creating-a-pull-request-from-a-fork)** to an **experimental branch**.

  - Depending on your schedule and the amount of work required to implement the proposed feature, choose the **appropriate experimental branch (`experimental/#.#.#`)**. 
  
  ***Experimental versions are the early stages of upcoming releases** and are where new features are being developed and implemented. **Once an experimental version matures**, it moves to **pre-release state**, during which new features and fixes are thoroughly tested to ensure they work as intended and do not introduce breaking changes to existing projects without a properly documented migration path.

- **Always [resolve any merge conflicts](https://help.github.com/en/github/collaborating-with-issues-and-pull-requests/resolving-a-merge-conflict-on-github) introduced by your pull request.**

- **Use properly constructed sentences in comments, including punctuation.**




## Writing Commit Messages

Please make sure you [write a great commit message](https://chris.beams.io/posts/git-commit/).

1. Separate the subject from the body with a blank line.
1. Limit the subject line to 50 characters.
1. Capitalize the subject line.
1. Subject lines should end with a period.
1. Wrap the body at about 72 characters.
1. Use the body to explain **why**, not what and how.

The following example shows how to properly structure a commit message:

```
Summarize the changes in about 50 characters or less.

If necessary, provide a more detailed explanatory text. Wrap it to about 72 characters or so. In some contexts, the first line is treated as the subject of the commit and the rest of the text as the body. The blank line separating the summary from the body is critical (unless you omit the body entirely); various tools like `log`, `shortlog` and `rebase` can get confused if you run the two together.

Explain the problem that this commit is solving. Focus on why you are making this change as opposed to how (the code explains that). Are there any side effects or other unintuitive consequences of this change? This is the place to explain them.

Further paragraphs come after blank lines.

 - Bullet points are okay too.

 - A hyphen should be used for the bullet, preceded by a single space and blank lines in between.

If applicable, put references to issues at the bottom, like this:

Resolves: #123
See also: #456, #789
```




## Code Review

- **Review the code, NOT the author.** Aim to **provide constructive feedback** that helps improve the codebase and **avoid making personal remarks or disparaging comments**. Your feedback should be actionable and clear, providing specific suggestions for improvement. Always, explain your reasoning.

- **You are not your code.** When your code is critiqued, questioned, or constructively criticized, remember that you are not your code. **Do not take code reviews personally.** Feedback is about improving the codebase, not evaluating you as an individual.

- **Always strive to do your best** and view mistakes as learning opportunities. No one writes bugs on purpose.

- **Please identify any violations of the guidelines** specified in this document. 




## Coding Style

Consistency is crucial. Follow the existing style, formatting, and naming conventions of the file you are modifying and of the overall project. Failure to do so will result in a prolonged review process that focuses on updating superficial aspects of your code, rather than improving its functionality and performance.

For example, if all private properties are prefixed with an underscore (`_`), then new ones you add should be prefixed similarly. Or, if methods are named using specific case, like `ThisIsMyNewMethod`, avoid diverging from this convention by using a different case like `this_is_my_new_method`. If you are unsure, please ask or search the codebase for similar examples.

When possible, style and format will be enforced with a linter.




## [No Brown M&M's](https://en.wikipedia.org/wiki/Van_Halen#Contract_riders)

If you are reading this, congratulations and thank you for making it this far! You are awesome. :100: To confirm that you have read this guide and are following it, **please include this emoji at the top** of your issue or pull request: :baby_chick: `:baby_chick:`




## Credits

- [Original Guide](https://github.com/jessesquires/.github/blob/main/CONTRIBUTING.md) created by [@jessesquires](https://github.com/jessesquires).
- [How to Write a Git Commit Message](https://chris.beams.io/posts/git-commit/) created by [@cbeams](https://github.com/cbeams).
