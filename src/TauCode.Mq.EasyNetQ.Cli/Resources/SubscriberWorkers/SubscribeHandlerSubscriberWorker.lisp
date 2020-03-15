(defblock :name subscribe-handler :is-top t
	(worker
		:worker-name subscribe-handler
		:verb "handler"
		:description "Subscribes a handler to the subscriber."
		:usage-samples (
			"sub handler Foo.Handlers.MyHandler"
			"sub handler Foo.Handlers.AnotherHandler -t 'some-topic'"
			"sub handler Foo.Handlers.AnotherHandler --topic 'some-topic'"))

	(some-text
		:classes term string
		:action argument
		:alias type-name
		:description "Type name, or part of type name."
		:doc-subst "type name")

	(opt
		(multi-text
			:classes key
			:values "-t" "--topic"
			:alias topic
			:action key)

		(some-text
			:classes path string
			:action value
			:description "Topic to subscribe to."
			:doc-subst "topic")
	)

	(end)
)
