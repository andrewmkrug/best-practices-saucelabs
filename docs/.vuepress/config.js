module.exports = {
  title: 'Test Automation Best Practices',
  description: 'Automation testing best practices',
  themeConfig: {
    nav: [
      { text: 'Home', link: '/' },
      { text: 'About', link: '/about/' },
      { text: 'Contact', link: '/contact/' }
    ],
    sidebar: [
      {
        title: 'Exercises',
        collapsable: false,
        children: [
          '/exercises/exercise1.md',
          '/exercises/exercise2.md',
          '/exercises/exercise3.md',
            '/exercises/exercise4.md'
        ]
      }
    ]
  }
}
